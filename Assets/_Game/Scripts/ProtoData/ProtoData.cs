// <auto-generated>
//     Generated by the protocol buffer compiler.  DO NOT EDIT!
//     source: ProtoData.proto
// </auto-generated>
#pragma warning disable 1591, 0612, 3021, 8981
#region Designer generated code

using pb = global::Google.Protobuf;
using pbc = global::Google.Protobuf.Collections;
using pbr = global::Google.Protobuf.Reflection;
using scg = global::System.Collections.Generic;
/// <summary>Holder for reflection information generated from ProtoData.proto</summary>
public static partial class ProtoDataReflection {

  #region Descriptor
  /// <summary>File descriptor for ProtoData.proto</summary>
  public static pbr::FileDescriptor Descriptor {
    get { return descriptor; }
  }
  private static pbr::FileDescriptor descriptor;

  static ProtoDataReflection() {
    byte[] descriptorData = global::System.Convert.FromBase64String(
        string.Concat(
          "Cg9Qcm90b0RhdGEucHJvdG8iMAoNUHJvdG9UYXNrRGF0YRIfCgZvcmRlcnMY",
          "ASADKAsyDy5Qcm90b09yZGVyRGF0YSIrCg5Qcm90b09yZGVyRGF0YRIKCgJp",
          "ZBgBIAEoCRINCgVpdGVtcxgCIAMoCSJDCg1Qcm90b0dyaWREYXRhEh0KBWNl",
          "bGxzGAEgAygLMg4uUHJvdG9DZWxsRGF0YRITCgtjb2xsZWN0aW9ucxgCIAMo",
          "CSJeCg1Qcm90b0NlbGxEYXRhEhEKCXBvc2l0aW9uWBgBIAEoBRIRCglwb3Np",
          "dGlvblkYAiABKAUSEAoIY2VsbFR5cGUYAyABKAUSFQoNaXRlbVNob3J0Q29k",
          "ZRgEIAEoCWIGcHJvdG8z"));
    descriptor = pbr::FileDescriptor.FromGeneratedCode(descriptorData,
        new pbr::FileDescriptor[] { },
        new pbr::GeneratedClrTypeInfo(null, null, new pbr::GeneratedClrTypeInfo[] {
          new pbr::GeneratedClrTypeInfo(typeof(global::ProtoTaskData), global::ProtoTaskData.Parser, new[]{ "Orders" }, null, null, null, null),
          new pbr::GeneratedClrTypeInfo(typeof(global::ProtoOrderData), global::ProtoOrderData.Parser, new[]{ "Id", "Items" }, null, null, null, null),
          new pbr::GeneratedClrTypeInfo(typeof(global::ProtoGridData), global::ProtoGridData.Parser, new[]{ "Cells", "Collections" }, null, null, null, null),
          new pbr::GeneratedClrTypeInfo(typeof(global::ProtoCellData), global::ProtoCellData.Parser, new[]{ "PositionX", "PositionY", "CellType", "ItemShortCode" }, null, null, null, null)
        }));
  }
  #endregion

}
#region Messages
[global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
public sealed partial class ProtoTaskData : pb::IMessage<ProtoTaskData>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<ProtoTaskData> _parser = new pb::MessageParser<ProtoTaskData>(() => new ProtoTaskData());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pb::MessageParser<ProtoTaskData> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::ProtoDataReflection.Descriptor.MessageTypes[0]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public ProtoTaskData() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public ProtoTaskData(ProtoTaskData other) : this() {
    orders_ = other.orders_.Clone();
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public ProtoTaskData Clone() {
    return new ProtoTaskData(this);
  }

  /// <summary>Field number for the "orders" field.</summary>
  public const int OrdersFieldNumber = 1;
  private static readonly pb::FieldCodec<global::ProtoOrderData> _repeated_orders_codec
      = pb::FieldCodec.ForMessage(10, global::ProtoOrderData.Parser);
  private readonly pbc::RepeatedField<global::ProtoOrderData> orders_ = new pbc::RepeatedField<global::ProtoOrderData>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public pbc::RepeatedField<global::ProtoOrderData> Orders {
    get { return orders_; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override bool Equals(object other) {
    return Equals(other as ProtoTaskData);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public bool Equals(ProtoTaskData other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if(!orders_.Equals(other.orders_)) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override int GetHashCode() {
    int hash = 1;
    hash ^= orders_.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void WriteTo(pb::CodedOutputStream output) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    output.WriteRawMessage(this);
  #else
    orders_.WriteTo(output, _repeated_orders_codec);
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
    orders_.WriteTo(ref output, _repeated_orders_codec);
    if (_unknownFields != null) {
      _unknownFields.WriteTo(ref output);
    }
  }
  #endif

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int CalculateSize() {
    int size = 0;
    size += orders_.CalculateSize(_repeated_orders_codec);
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(ProtoTaskData other) {
    if (other == null) {
      return;
    }
    orders_.Add(other.orders_);
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(pb::CodedInputStream input) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    input.ReadRawMessage(this);
  #else
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
    if ((tag & 7) == 4) {
      // Abort on any end group tag.
      return;
    }
    switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 10: {
          orders_.AddEntriesFrom(input, _repeated_orders_codec);
          break;
        }
      }
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
    if ((tag & 7) == 4) {
      // Abort on any end group tag.
      return;
    }
    switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
          break;
        case 10: {
          orders_.AddEntriesFrom(ref input, _repeated_orders_codec);
          break;
        }
      }
    }
  }
  #endif

}

[global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
public sealed partial class ProtoOrderData : pb::IMessage<ProtoOrderData>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<ProtoOrderData> _parser = new pb::MessageParser<ProtoOrderData>(() => new ProtoOrderData());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pb::MessageParser<ProtoOrderData> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::ProtoDataReflection.Descriptor.MessageTypes[1]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public ProtoOrderData() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public ProtoOrderData(ProtoOrderData other) : this() {
    id_ = other.id_;
    items_ = other.items_.Clone();
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public ProtoOrderData Clone() {
    return new ProtoOrderData(this);
  }

  /// <summary>Field number for the "id" field.</summary>
  public const int IdFieldNumber = 1;
  private string id_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string Id {
    get { return id_; }
    set {
      id_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  /// <summary>Field number for the "items" field.</summary>
  public const int ItemsFieldNumber = 2;
  private static readonly pb::FieldCodec<string> _repeated_items_codec
      = pb::FieldCodec.ForString(18);
  private readonly pbc::RepeatedField<string> items_ = new pbc::RepeatedField<string>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public pbc::RepeatedField<string> Items {
    get { return items_; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override bool Equals(object other) {
    return Equals(other as ProtoOrderData);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public bool Equals(ProtoOrderData other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (Id != other.Id) return false;
    if(!items_.Equals(other.items_)) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override int GetHashCode() {
    int hash = 1;
    if (Id.Length != 0) hash ^= Id.GetHashCode();
    hash ^= items_.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void WriteTo(pb::CodedOutputStream output) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    output.WriteRawMessage(this);
  #else
    if (Id.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Id);
    }
    items_.WriteTo(output, _repeated_items_codec);
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
    if (Id.Length != 0) {
      output.WriteRawTag(10);
      output.WriteString(Id);
    }
    items_.WriteTo(ref output, _repeated_items_codec);
    if (_unknownFields != null) {
      _unknownFields.WriteTo(ref output);
    }
  }
  #endif

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int CalculateSize() {
    int size = 0;
    if (Id.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(Id);
    }
    size += items_.CalculateSize(_repeated_items_codec);
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(ProtoOrderData other) {
    if (other == null) {
      return;
    }
    if (other.Id.Length != 0) {
      Id = other.Id;
    }
    items_.Add(other.items_);
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(pb::CodedInputStream input) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    input.ReadRawMessage(this);
  #else
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
    if ((tag & 7) == 4) {
      // Abort on any end group tag.
      return;
    }
    switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 10: {
          Id = input.ReadString();
          break;
        }
        case 18: {
          items_.AddEntriesFrom(input, _repeated_items_codec);
          break;
        }
      }
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
    if ((tag & 7) == 4) {
      // Abort on any end group tag.
      return;
    }
    switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
          break;
        case 10: {
          Id = input.ReadString();
          break;
        }
        case 18: {
          items_.AddEntriesFrom(ref input, _repeated_items_codec);
          break;
        }
      }
    }
  }
  #endif

}

[global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
public sealed partial class ProtoGridData : pb::IMessage<ProtoGridData>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<ProtoGridData> _parser = new pb::MessageParser<ProtoGridData>(() => new ProtoGridData());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pb::MessageParser<ProtoGridData> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::ProtoDataReflection.Descriptor.MessageTypes[2]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public ProtoGridData() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public ProtoGridData(ProtoGridData other) : this() {
    cells_ = other.cells_.Clone();
    collections_ = other.collections_.Clone();
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public ProtoGridData Clone() {
    return new ProtoGridData(this);
  }

  /// <summary>Field number for the "cells" field.</summary>
  public const int CellsFieldNumber = 1;
  private static readonly pb::FieldCodec<global::ProtoCellData> _repeated_cells_codec
      = pb::FieldCodec.ForMessage(10, global::ProtoCellData.Parser);
  private readonly pbc::RepeatedField<global::ProtoCellData> cells_ = new pbc::RepeatedField<global::ProtoCellData>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public pbc::RepeatedField<global::ProtoCellData> Cells {
    get { return cells_; }
  }

  /// <summary>Field number for the "collections" field.</summary>
  public const int CollectionsFieldNumber = 2;
  private static readonly pb::FieldCodec<string> _repeated_collections_codec
      = pb::FieldCodec.ForString(18);
  private readonly pbc::RepeatedField<string> collections_ = new pbc::RepeatedField<string>();
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public pbc::RepeatedField<string> Collections {
    get { return collections_; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override bool Equals(object other) {
    return Equals(other as ProtoGridData);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public bool Equals(ProtoGridData other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if(!cells_.Equals(other.cells_)) return false;
    if(!collections_.Equals(other.collections_)) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override int GetHashCode() {
    int hash = 1;
    hash ^= cells_.GetHashCode();
    hash ^= collections_.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void WriteTo(pb::CodedOutputStream output) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    output.WriteRawMessage(this);
  #else
    cells_.WriteTo(output, _repeated_cells_codec);
    collections_.WriteTo(output, _repeated_collections_codec);
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
    cells_.WriteTo(ref output, _repeated_cells_codec);
    collections_.WriteTo(ref output, _repeated_collections_codec);
    if (_unknownFields != null) {
      _unknownFields.WriteTo(ref output);
    }
  }
  #endif

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int CalculateSize() {
    int size = 0;
    size += cells_.CalculateSize(_repeated_cells_codec);
    size += collections_.CalculateSize(_repeated_collections_codec);
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(ProtoGridData other) {
    if (other == null) {
      return;
    }
    cells_.Add(other.cells_);
    collections_.Add(other.collections_);
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(pb::CodedInputStream input) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    input.ReadRawMessage(this);
  #else
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
    if ((tag & 7) == 4) {
      // Abort on any end group tag.
      return;
    }
    switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 10: {
          cells_.AddEntriesFrom(input, _repeated_cells_codec);
          break;
        }
        case 18: {
          collections_.AddEntriesFrom(input, _repeated_collections_codec);
          break;
        }
      }
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
    if ((tag & 7) == 4) {
      // Abort on any end group tag.
      return;
    }
    switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
          break;
        case 10: {
          cells_.AddEntriesFrom(ref input, _repeated_cells_codec);
          break;
        }
        case 18: {
          collections_.AddEntriesFrom(ref input, _repeated_collections_codec);
          break;
        }
      }
    }
  }
  #endif

}

[global::System.Diagnostics.DebuggerDisplayAttribute("{ToString(),nq}")]
public sealed partial class ProtoCellData : pb::IMessage<ProtoCellData>
#if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    , pb::IBufferMessage
#endif
{
  private static readonly pb::MessageParser<ProtoCellData> _parser = new pb::MessageParser<ProtoCellData>(() => new ProtoCellData());
  private pb::UnknownFieldSet _unknownFields;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pb::MessageParser<ProtoCellData> Parser { get { return _parser; } }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public static pbr::MessageDescriptor Descriptor {
    get { return global::ProtoDataReflection.Descriptor.MessageTypes[3]; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  pbr::MessageDescriptor pb::IMessage.Descriptor {
    get { return Descriptor; }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public ProtoCellData() {
    OnConstruction();
  }

  partial void OnConstruction();

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public ProtoCellData(ProtoCellData other) : this() {
    positionX_ = other.positionX_;
    positionY_ = other.positionY_;
    cellType_ = other.cellType_;
    itemShortCode_ = other.itemShortCode_;
    _unknownFields = pb::UnknownFieldSet.Clone(other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public ProtoCellData Clone() {
    return new ProtoCellData(this);
  }

  /// <summary>Field number for the "positionX" field.</summary>
  public const int PositionXFieldNumber = 1;
  private int positionX_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int PositionX {
    get { return positionX_; }
    set {
      positionX_ = value;
    }
  }

  /// <summary>Field number for the "positionY" field.</summary>
  public const int PositionYFieldNumber = 2;
  private int positionY_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int PositionY {
    get { return positionY_; }
    set {
      positionY_ = value;
    }
  }

  /// <summary>Field number for the "cellType" field.</summary>
  public const int CellTypeFieldNumber = 3;
  private int cellType_;
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int CellType {
    get { return cellType_; }
    set {
      cellType_ = value;
    }
  }

  /// <summary>Field number for the "itemShortCode" field.</summary>
  public const int ItemShortCodeFieldNumber = 4;
  private string itemShortCode_ = "";
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public string ItemShortCode {
    get { return itemShortCode_; }
    set {
      itemShortCode_ = pb::ProtoPreconditions.CheckNotNull(value, "value");
    }
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override bool Equals(object other) {
    return Equals(other as ProtoCellData);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public bool Equals(ProtoCellData other) {
    if (ReferenceEquals(other, null)) {
      return false;
    }
    if (ReferenceEquals(other, this)) {
      return true;
    }
    if (PositionX != other.PositionX) return false;
    if (PositionY != other.PositionY) return false;
    if (CellType != other.CellType) return false;
    if (ItemShortCode != other.ItemShortCode) return false;
    return Equals(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override int GetHashCode() {
    int hash = 1;
    if (PositionX != 0) hash ^= PositionX.GetHashCode();
    if (PositionY != 0) hash ^= PositionY.GetHashCode();
    if (CellType != 0) hash ^= CellType.GetHashCode();
    if (ItemShortCode.Length != 0) hash ^= ItemShortCode.GetHashCode();
    if (_unknownFields != null) {
      hash ^= _unknownFields.GetHashCode();
    }
    return hash;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public override string ToString() {
    return pb::JsonFormatter.ToDiagnosticString(this);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void WriteTo(pb::CodedOutputStream output) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    output.WriteRawMessage(this);
  #else
    if (PositionX != 0) {
      output.WriteRawTag(8);
      output.WriteInt32(PositionX);
    }
    if (PositionY != 0) {
      output.WriteRawTag(16);
      output.WriteInt32(PositionY);
    }
    if (CellType != 0) {
      output.WriteRawTag(24);
      output.WriteInt32(CellType);
    }
    if (ItemShortCode.Length != 0) {
      output.WriteRawTag(34);
      output.WriteString(ItemShortCode);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(output);
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalWriteTo(ref pb::WriteContext output) {
    if (PositionX != 0) {
      output.WriteRawTag(8);
      output.WriteInt32(PositionX);
    }
    if (PositionY != 0) {
      output.WriteRawTag(16);
      output.WriteInt32(PositionY);
    }
    if (CellType != 0) {
      output.WriteRawTag(24);
      output.WriteInt32(CellType);
    }
    if (ItemShortCode.Length != 0) {
      output.WriteRawTag(34);
      output.WriteString(ItemShortCode);
    }
    if (_unknownFields != null) {
      _unknownFields.WriteTo(ref output);
    }
  }
  #endif

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public int CalculateSize() {
    int size = 0;
    if (PositionX != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(PositionX);
    }
    if (PositionY != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(PositionY);
    }
    if (CellType != 0) {
      size += 1 + pb::CodedOutputStream.ComputeInt32Size(CellType);
    }
    if (ItemShortCode.Length != 0) {
      size += 1 + pb::CodedOutputStream.ComputeStringSize(ItemShortCode);
    }
    if (_unknownFields != null) {
      size += _unknownFields.CalculateSize();
    }
    return size;
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(ProtoCellData other) {
    if (other == null) {
      return;
    }
    if (other.PositionX != 0) {
      PositionX = other.PositionX;
    }
    if (other.PositionY != 0) {
      PositionY = other.PositionY;
    }
    if (other.CellType != 0) {
      CellType = other.CellType;
    }
    if (other.ItemShortCode.Length != 0) {
      ItemShortCode = other.ItemShortCode;
    }
    _unknownFields = pb::UnknownFieldSet.MergeFrom(_unknownFields, other._unknownFields);
  }

  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  public void MergeFrom(pb::CodedInputStream input) {
  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
    input.ReadRawMessage(this);
  #else
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
    if ((tag & 7) == 4) {
      // Abort on any end group tag.
      return;
    }
    switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, input);
          break;
        case 8: {
          PositionX = input.ReadInt32();
          break;
        }
        case 16: {
          PositionY = input.ReadInt32();
          break;
        }
        case 24: {
          CellType = input.ReadInt32();
          break;
        }
        case 34: {
          ItemShortCode = input.ReadString();
          break;
        }
      }
    }
  #endif
  }

  #if !GOOGLE_PROTOBUF_REFSTRUCT_COMPATIBILITY_MODE
  [global::System.Diagnostics.DebuggerNonUserCodeAttribute]
  [global::System.CodeDom.Compiler.GeneratedCode("protoc", null)]
  void pb::IBufferMessage.InternalMergeFrom(ref pb::ParseContext input) {
    uint tag;
    while ((tag = input.ReadTag()) != 0) {
    if ((tag & 7) == 4) {
      // Abort on any end group tag.
      return;
    }
    switch(tag) {
        default:
          _unknownFields = pb::UnknownFieldSet.MergeFieldFrom(_unknownFields, ref input);
          break;
        case 8: {
          PositionX = input.ReadInt32();
          break;
        }
        case 16: {
          PositionY = input.ReadInt32();
          break;
        }
        case 24: {
          CellType = input.ReadInt32();
          break;
        }
        case 34: {
          ItemShortCode = input.ReadString();
          break;
        }
      }
    }
  }
  #endif

}

#endregion


#endregion Designer generated code
